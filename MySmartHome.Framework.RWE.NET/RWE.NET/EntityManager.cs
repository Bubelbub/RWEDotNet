using RWE.NET.Entity.Device;
using RWE.NET.Entity;
using RWE.NET.Request;
using RWE.NET.Response;
using System.Collections.Generic;
using RWE.NET.Interface;
using RWE.NET.Entity.Profiles;

namespace RWE.NET
{
    /// <summary>
    /// Behandelt die logischen Geräte und Räume der Zentrale
    /// </summary>
    /// <author>Marko Geißler (marko.geissler@googlemail.com)</author>
    public class EntityManager
    {
        List<LogicalDevice> logicalDevices;
        List<Location> locations;
        List<Profile> profiles;
        IRequestHandler requestHandler;

        /// <summary>
        /// Erzeugt eine neue Instanz der Klasse
        /// </summary>
        /// <param name="requestHandler">Instanz von RequestHandler</param>
        public EntityManager(IRequestHandler requestHandler)
        {
            this.requestHandler = requestHandler;
            var request = new GetEntitiesRequest()
            {
                EntityType = "Configuration"
            };

            GetEntitiesResponse response = requestHandler.RequestResponse<GetEntitiesRequest, GetEntitiesResponse>(request);
            logicalDevices = response.LogicalDevices;
            locations = response.Locations;
            profiles = response.Profiles;
        }

        /// <summary>
        /// Auflistung aller logischen Geräte
        /// </summary>
        public List<LogicalDevice> LogicalDevices
        {
            get
            {
                return logicalDevices;
            }
        }

        /// <summary>
        /// Auflistung aller Räume
        /// </summary>
        public List<Location> Locations
        {
            get
            {
                return locations;
            }
        }

        /// <summary>
        /// Auflistung aller Profile
        /// </summary>
        public List<Profile> Profiles
        {
            get
            {
                return profiles;
            }
        }
    }
}
