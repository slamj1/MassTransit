﻿// Copyright 2007-2016 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit
{
    using EndpointConfigurators;
    using ProtocolBuffers;


    public static class ProtocolBufferSerializationExtensions
    {
        /// <summary>
        /// Serialize messages using the BSON message serializer
        /// </summary>
        /// <param name="configurator"></param>
        public static void UseProtocolBuffersSerializer(this IBusFactoryConfigurator configurator)
        {
            configurator.AddBusFactorySpecification(new SetMessageSerializerBusFactorySpecification<ProtocolBuffersMessageSerializer>());

            SupportProtocolBuffersMessageDeserializer(configurator);
        }

        /// <summary>
        /// Add support for the binary message deserializer to the bus. This serializer is not supported
        /// by default.
        /// </summary>
        /// <param name="configurator"></param>
        /// <returns></returns>
        public static void SupportProtocolBuffersMessageDeserializer(this IBusFactoryConfigurator configurator)
        {
            configurator.AddBusFactorySpecification(new SupportMessageDeserializerBusFactorySpecification(
                ProtocolBuffersMessageSerializer.ProtocolBuffersContentType, () => new ProtocolBuffersMessageDeserializer()));
        }
    }
}