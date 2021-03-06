﻿using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace FreddieChatServer.Modes {

    /// <summary>
    /// Service mode used for HTTP (WSDualHttpBinding).
    /// </summary>
    public class HttpChatServiceMode : IChatServiceMode {

        public string Protocol {
            get {
                return "http";
            }
        }

        public bool IsPortRequired {
            get {
                return true;
            }
        }

        public Binding ServiceEndpointBinding {
            get;
            private set;
        }

        public Binding ServiceMetadataBinding {
            get;
            private set;
        }

        public IServiceBehavior ServiceBehavior {
            get;
            private set;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public HttpChatServiceMode() {
            var binding = new WSDualHttpBinding();
            binding.Security.Mode = WSDualHttpSecurityMode.None;
            ServiceEndpointBinding = binding;

            ServiceMetadataBinding = MetadataExchangeBindings.CreateMexHttpBinding();
            ServiceBehavior = new ServiceMetadataBehavior {
                MetadataExporter = {
                    PolicyVersion = PolicyVersion.Policy15
                },
                HttpGetEnabled = true
            };
        }

    }

}
