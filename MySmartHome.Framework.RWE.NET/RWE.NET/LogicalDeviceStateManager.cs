using RWE.NET.Entity;
using RWE.NET.Extensions;
using RWE.NET.Interface;
using RWE.NET.Request;
using RWE.NET.Response;
using RWE.NET.RWEEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace RWE.NET
{
    /// <summary>
    /// Der LogicalDeveiceStateManager übernimmt das Handling der LogicalDeviceStates.
    /// Es können Änderungen gespeichert werden und auch Updates von der Zentrale abgefragt werden.
    /// </summary>
    /// <author>Marko Geißler (marko.geissler@googlemail.com)</author>
    public class LogicalDeviceStateManager
    {
        private IRequestHandler requestHandler;
        private List<LogicalDeviceState> logicalDeviceStates;

        public delegate void LogicalDeviceStateUpdatedEventHandler(object sender, LogicalDeviceStateUpdatedEventArgs e);

        /// <summary>
        /// Wird ausgelöst, wenn ein Update von der Zentrale empfangen wurde
        /// </summary>
        public event LogicalDeviceStateUpdatedEventHandler LogicalDeviceStateUpdated;


        /// <summary>
        /// Initialisiert eine neue Instanz des Klasse
        /// </summary>
        /// <param name="requestHandler">Instanz von RequestHandler</param>
        public LogicalDeviceStateManager(IRequestHandler requestHandler)
        {
            this.requestHandler = requestHandler;
            logicalDeviceStates = new List<LogicalDeviceState>();
            this.Initialize();
        }

        /// <summary>
        /// Liste aller LogicalDeviceStates
        /// </summary>
        public List<LogicalDeviceState> LogicalDeviceStates { get { return logicalDeviceStates; } }

        /// <summary>
        /// Sendet alle Änderungen an die Zentrale
        /// </summary>
        /// <returns>Gibt zurück ob der Speichervorgang erfolgreich war</returns>
        public bool SaveChanges()
        {
            var updatedStates = logicalDeviceStates.Where(x => x.ChangeTracker.Keys.Any()).ToList();
            var request = new SetActuatorStatesRequest()
            {
                ActuatorStates = updatedStates
            };
            if (requestHandler.RequestResponse<SetActuatorStatesRequest, ControlResultResponse>(request)
                .Result.Equals("ok",StringComparison.InvariantCultureIgnoreCase))
            {
                updatedStates.ForEach(x =>
                {
                    x.ChangeTracker.Clear();
                });
                return true;
            }
            else
                return false;

        }


        /// <summary>
        /// Fordert ein Update von der Zentrale an und führt die Änderungen in der Liste der LogicalDeviceStates durch
        /// </summary>
        /// <returns>eine Liste mit geänderten LogicalDeviceStates</returns>
        public List<LogicalDeviceState> DoUpdate()
        {
            List<LogicalDeviceState> states = new List<LogicalDeviceState>();
            try
            {
                var list = requestHandler.RequestUpdate().Notifications;
                foreach (var notification in list)
                {
                    LogicalDeviceStatesChangedNotification logicalDeviceStatesChangedNotification = notification as LogicalDeviceStatesChangedNotification;
                    if (logicalDeviceStatesChangedNotification != null)
                    {
                        foreach (LogicalDeviceState state in logicalDeviceStatesChangedNotification.LogicalDeviceStates)
                        {
                            logicalDeviceStates
                                .Find(x => x.LogicalDeviceId == state.LogicalDeviceId).ApplyPropertyChanges(state);

                        }
                        states.AddRange(logicalDeviceStatesChangedNotification.LogicalDeviceStates);
                    }
                }
            }
            catch (WebException webex)
            {
                //Die Session ist abgelaufen und der DeviceManager wird neu initialisiert
                HttpWebResponse response = (System.Net.HttpWebResponse)webex.Response;
                if (response.StatusCode == HttpStatusCode.MethodNotAllowed)
                {
                    this.Initialize();
                }
            }
            if (states != null && LogicalDeviceStateUpdated != null)
            {
                LogicalDeviceStateUpdatedEventArgs deviceUpdatedEventArgs = new LogicalDeviceStateUpdatedEventArgs
                {
                    States = states
                };
                LogicalDeviceStateUpdated(this, deviceUpdatedEventArgs);
            }
            return states;
        }

        private void Initialize()
        {
            GetAllLogicalDeviceStatesRequest request = new GetAllLogicalDeviceStatesRequest();
            GetAllLogicalDeviceStatesResponse logicalDeviceStates = requestHandler.RequestResponse<GetAllLogicalDeviceStatesRequest, GetAllLogicalDeviceStatesResponse>(request);
            this.logicalDeviceStates = logicalDeviceStates.States;
            logicalDeviceStates.States.ForEach(x => { x.InitializeChangeTracker(); });

            NotificationRequest nr = new NotificationRequest();
            nr.NotificationType = "DeviceStateChanges";
            nr.Action = "Subscribe";
            requestHandler.RequestResponse<NotificationRequest, AcknowledgeResponse>(nr);
        }
    }
}
