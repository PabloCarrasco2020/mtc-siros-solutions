﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wsSoapSUNARP
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://service.WSVehicular.sunarp.gob.pe/", ConfigurationName="wsSoapSUNARP.WSVehicularMtcDelegate")]
    public interface WSVehicularMtcDelegate
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<wsSoapSUNARP.buscarAutosResponse> buscarAutosAsync(wsSoapSUNARP.buscarAutosRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<wsSoapSUNARP.getDatosVehicularResponse> getDatosVehicularAsync(wsSoapSUNARP.getDatosVehicularRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<wsSoapSUNARP.getDatosVehicularAAPResponse> getDatosVehicularAAPAsync(wsSoapSUNARP.getDatosVehicularAAPRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<wsSoapSUNARP.getConsultaXChasisResponse> getConsultaXChasisAsync(wsSoapSUNARP.getConsultaXChasisRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<wsSoapSUNARP.getConsultaXPorPlacaVigenteResponse> getConsultaXPorPlacaVigenteAsync(wsSoapSUNARP.getConsultaXPorPlacaVigenteRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<wsSoapSUNARP.getConsultaxPlacaMTCResponse> getConsultaxPlacaMTCAsync(wsSoapSUNARP.getConsultaxPlacaMTCRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class buscarAutosRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="buscarAutos", Namespace="http://service.WSVehicular.sunarp.gob.pe/", Order=0)]
        public wsSoapSUNARP.buscarAutosRequestBody Body;
        
        public buscarAutosRequest()
        {
        }
        
        public buscarAutosRequest(wsSoapSUNARP.buscarAutosRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class buscarAutosRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string arg0;
        
        public buscarAutosRequestBody()
        {
        }
        
        public buscarAutosRequestBody(string arg0)
        {
            this.arg0 = arg0;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class buscarAutosResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="buscarAutosResponse", Namespace="http://service.WSVehicular.sunarp.gob.pe/", Order=0)]
        public wsSoapSUNARP.buscarAutosResponseBody Body;
        
        public buscarAutosResponse()
        {
        }
        
        public buscarAutosResponse(wsSoapSUNARP.buscarAutosResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class buscarAutosResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string @return;
        
        public buscarAutosResponseBody()
        {
        }
        
        public buscarAutosResponseBody(string @return)
        {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getDatosVehicularRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="getDatosVehicular", Namespace="http://service.WSVehicular.sunarp.gob.pe/", Order=0)]
        public wsSoapSUNARP.getDatosVehicularRequestBody Body;
        
        public getDatosVehicularRequest()
        {
        }
        
        public getDatosVehicularRequest(wsSoapSUNARP.getDatosVehicularRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class getDatosVehicularRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string arg0;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string arg1;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string arg2;
        
        public getDatosVehicularRequestBody()
        {
        }
        
        public getDatosVehicularRequestBody(string arg0, string arg1, string arg2)
        {
            this.arg0 = arg0;
            this.arg1 = arg1;
            this.arg2 = arg2;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getDatosVehicularResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="getDatosVehicularResponse", Namespace="http://service.WSVehicular.sunarp.gob.pe/", Order=0)]
        public wsSoapSUNARP.getDatosVehicularResponseBody Body;
        
        public getDatosVehicularResponse()
        {
        }
        
        public getDatosVehicularResponse(wsSoapSUNARP.getDatosVehicularResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class getDatosVehicularResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string @return;
        
        public getDatosVehicularResponseBody()
        {
        }
        
        public getDatosVehicularResponseBody(string @return)
        {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getDatosVehicularAAPRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="getDatosVehicularAAP", Namespace="http://service.WSVehicular.sunarp.gob.pe/", Order=0)]
        public wsSoapSUNARP.getDatosVehicularAAPRequestBody Body;
        
        public getDatosVehicularAAPRequest()
        {
        }
        
        public getDatosVehicularAAPRequest(wsSoapSUNARP.getDatosVehicularAAPRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class getDatosVehicularAAPRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string arg0;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string arg1;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string arg2;
        
        public getDatosVehicularAAPRequestBody()
        {
        }
        
        public getDatosVehicularAAPRequestBody(string arg0, string arg1, string arg2)
        {
            this.arg0 = arg0;
            this.arg1 = arg1;
            this.arg2 = arg2;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getDatosVehicularAAPResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="getDatosVehicularAAPResponse", Namespace="http://service.WSVehicular.sunarp.gob.pe/", Order=0)]
        public wsSoapSUNARP.getDatosVehicularAAPResponseBody Body;
        
        public getDatosVehicularAAPResponse()
        {
        }
        
        public getDatosVehicularAAPResponse(wsSoapSUNARP.getDatosVehicularAAPResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class getDatosVehicularAAPResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string @return;
        
        public getDatosVehicularAAPResponseBody()
        {
        }
        
        public getDatosVehicularAAPResponseBody(string @return)
        {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getConsultaXChasisRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="getConsultaXChasis", Namespace="http://service.WSVehicular.sunarp.gob.pe/", Order=0)]
        public wsSoapSUNARP.getConsultaXChasisRequestBody Body;
        
        public getConsultaXChasisRequest()
        {
        }
        
        public getConsultaXChasisRequest(wsSoapSUNARP.getConsultaXChasisRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class getConsultaXChasisRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string arg0;
        
        public getConsultaXChasisRequestBody()
        {
        }
        
        public getConsultaXChasisRequestBody(string arg0)
        {
            this.arg0 = arg0;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getConsultaXChasisResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="getConsultaXChasisResponse", Namespace="http://service.WSVehicular.sunarp.gob.pe/", Order=0)]
        public wsSoapSUNARP.getConsultaXChasisResponseBody Body;
        
        public getConsultaXChasisResponse()
        {
        }
        
        public getConsultaXChasisResponse(wsSoapSUNARP.getConsultaXChasisResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class getConsultaXChasisResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string @return;
        
        public getConsultaXChasisResponseBody()
        {
        }
        
        public getConsultaXChasisResponseBody(string @return)
        {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getConsultaXPorPlacaVigenteRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="getConsultaXPorPlacaVigente", Namespace="http://service.WSVehicular.sunarp.gob.pe/", Order=0)]
        public wsSoapSUNARP.getConsultaXPorPlacaVigenteRequestBody Body;
        
        public getConsultaXPorPlacaVigenteRequest()
        {
        }
        
        public getConsultaXPorPlacaVigenteRequest(wsSoapSUNARP.getConsultaXPorPlacaVigenteRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class getConsultaXPorPlacaVigenteRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string arg0;
        
        public getConsultaXPorPlacaVigenteRequestBody()
        {
        }
        
        public getConsultaXPorPlacaVigenteRequestBody(string arg0)
        {
            this.arg0 = arg0;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getConsultaXPorPlacaVigenteResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="getConsultaXPorPlacaVigenteResponse", Namespace="http://service.WSVehicular.sunarp.gob.pe/", Order=0)]
        public wsSoapSUNARP.getConsultaXPorPlacaVigenteResponseBody Body;
        
        public getConsultaXPorPlacaVigenteResponse()
        {
        }
        
        public getConsultaXPorPlacaVigenteResponse(wsSoapSUNARP.getConsultaXPorPlacaVigenteResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class getConsultaXPorPlacaVigenteResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string @return;
        
        public getConsultaXPorPlacaVigenteResponseBody()
        {
        }
        
        public getConsultaXPorPlacaVigenteResponseBody(string @return)
        {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getConsultaxPlacaMTCRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="getConsultaxPlacaMTC", Namespace="http://service.WSVehicular.sunarp.gob.pe/", Order=0)]
        public wsSoapSUNARP.getConsultaxPlacaMTCRequestBody Body;
        
        public getConsultaxPlacaMTCRequest()
        {
        }
        
        public getConsultaxPlacaMTCRequest(wsSoapSUNARP.getConsultaxPlacaMTCRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class getConsultaxPlacaMTCRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string arg0;
        
        public getConsultaxPlacaMTCRequestBody()
        {
        }
        
        public getConsultaxPlacaMTCRequestBody(string arg0)
        {
            this.arg0 = arg0;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getConsultaxPlacaMTCResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="getConsultaxPlacaMTCResponse", Namespace="http://service.WSVehicular.sunarp.gob.pe/", Order=0)]
        public wsSoapSUNARP.getConsultaxPlacaMTCResponseBody Body;
        
        public getConsultaxPlacaMTCResponse()
        {
        }
        
        public getConsultaxPlacaMTCResponse(wsSoapSUNARP.getConsultaxPlacaMTCResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class getConsultaxPlacaMTCResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string @return;
        
        public getConsultaxPlacaMTCResponseBody()
        {
        }
        
        public getConsultaxPlacaMTCResponseBody(string @return)
        {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    public interface WSVehicularMtcDelegateChannel : wsSoapSUNARP.WSVehicularMtcDelegate, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    public partial class WSVehicularMtcDelegateClient : System.ServiceModel.ClientBase<wsSoapSUNARP.WSVehicularMtcDelegate>, wsSoapSUNARP.WSVehicularMtcDelegate
    {
        
        /// <summary>
        /// Implemente este método parcial para configurar el punto de conexión de servicio.
        /// </summary>
        /// <param name="serviceEndpoint">El punto de conexión para configurar</param>
        /// <param name="clientCredentials">Credenciales de cliente</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public WSVehicularMtcDelegateClient() : 
                base(WSVehicularMtcDelegateClient.GetDefaultBinding(), WSVehicularMtcDelegateClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.WSVehicularMtcPort.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WSVehicularMtcDelegateClient(EndpointConfiguration endpointConfiguration) : 
                base(WSVehicularMtcDelegateClient.GetBindingForEndpoint(endpointConfiguration), WSVehicularMtcDelegateClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WSVehicularMtcDelegateClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(WSVehicularMtcDelegateClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WSVehicularMtcDelegateClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(WSVehicularMtcDelegateClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WSVehicularMtcDelegateClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<wsSoapSUNARP.buscarAutosResponse> wsSoapSUNARP.WSVehicularMtcDelegate.buscarAutosAsync(wsSoapSUNARP.buscarAutosRequest request)
        {
            return base.Channel.buscarAutosAsync(request);
        }
        
        public System.Threading.Tasks.Task<wsSoapSUNARP.buscarAutosResponse> buscarAutosAsync(string arg0)
        {
            wsSoapSUNARP.buscarAutosRequest inValue = new wsSoapSUNARP.buscarAutosRequest();
            inValue.Body = new wsSoapSUNARP.buscarAutosRequestBody();
            inValue.Body.arg0 = arg0;
            return ((wsSoapSUNARP.WSVehicularMtcDelegate)(this)).buscarAutosAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<wsSoapSUNARP.getDatosVehicularResponse> wsSoapSUNARP.WSVehicularMtcDelegate.getDatosVehicularAsync(wsSoapSUNARP.getDatosVehicularRequest request)
        {
            return base.Channel.getDatosVehicularAsync(request);
        }
        
        public System.Threading.Tasks.Task<wsSoapSUNARP.getDatosVehicularResponse> getDatosVehicularAsync(string arg0, string arg1, string arg2)
        {
            wsSoapSUNARP.getDatosVehicularRequest inValue = new wsSoapSUNARP.getDatosVehicularRequest();
            inValue.Body = new wsSoapSUNARP.getDatosVehicularRequestBody();
            inValue.Body.arg0 = arg0;
            inValue.Body.arg1 = arg1;
            inValue.Body.arg2 = arg2;
            return ((wsSoapSUNARP.WSVehicularMtcDelegate)(this)).getDatosVehicularAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<wsSoapSUNARP.getDatosVehicularAAPResponse> wsSoapSUNARP.WSVehicularMtcDelegate.getDatosVehicularAAPAsync(wsSoapSUNARP.getDatosVehicularAAPRequest request)
        {
            return base.Channel.getDatosVehicularAAPAsync(request);
        }
        
        public System.Threading.Tasks.Task<wsSoapSUNARP.getDatosVehicularAAPResponse> getDatosVehicularAAPAsync(string arg0, string arg1, string arg2)
        {
            wsSoapSUNARP.getDatosVehicularAAPRequest inValue = new wsSoapSUNARP.getDatosVehicularAAPRequest();
            inValue.Body = new wsSoapSUNARP.getDatosVehicularAAPRequestBody();
            inValue.Body.arg0 = arg0;
            inValue.Body.arg1 = arg1;
            inValue.Body.arg2 = arg2;
            return ((wsSoapSUNARP.WSVehicularMtcDelegate)(this)).getDatosVehicularAAPAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<wsSoapSUNARP.getConsultaXChasisResponse> wsSoapSUNARP.WSVehicularMtcDelegate.getConsultaXChasisAsync(wsSoapSUNARP.getConsultaXChasisRequest request)
        {
            return base.Channel.getConsultaXChasisAsync(request);
        }
        
        public System.Threading.Tasks.Task<wsSoapSUNARP.getConsultaXChasisResponse> getConsultaXChasisAsync(string arg0)
        {
            wsSoapSUNARP.getConsultaXChasisRequest inValue = new wsSoapSUNARP.getConsultaXChasisRequest();
            inValue.Body = new wsSoapSUNARP.getConsultaXChasisRequestBody();
            inValue.Body.arg0 = arg0;
            return ((wsSoapSUNARP.WSVehicularMtcDelegate)(this)).getConsultaXChasisAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<wsSoapSUNARP.getConsultaXPorPlacaVigenteResponse> wsSoapSUNARP.WSVehicularMtcDelegate.getConsultaXPorPlacaVigenteAsync(wsSoapSUNARP.getConsultaXPorPlacaVigenteRequest request)
        {
            return base.Channel.getConsultaXPorPlacaVigenteAsync(request);
        }
        
        public System.Threading.Tasks.Task<wsSoapSUNARP.getConsultaXPorPlacaVigenteResponse> getConsultaXPorPlacaVigenteAsync(string arg0)
        {
            wsSoapSUNARP.getConsultaXPorPlacaVigenteRequest inValue = new wsSoapSUNARP.getConsultaXPorPlacaVigenteRequest();
            inValue.Body = new wsSoapSUNARP.getConsultaXPorPlacaVigenteRequestBody();
            inValue.Body.arg0 = arg0;
            return ((wsSoapSUNARP.WSVehicularMtcDelegate)(this)).getConsultaXPorPlacaVigenteAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<wsSoapSUNARP.getConsultaxPlacaMTCResponse> wsSoapSUNARP.WSVehicularMtcDelegate.getConsultaxPlacaMTCAsync(wsSoapSUNARP.getConsultaxPlacaMTCRequest request)
        {
            return base.Channel.getConsultaxPlacaMTCAsync(request);
        }
        
        public System.Threading.Tasks.Task<wsSoapSUNARP.getConsultaxPlacaMTCResponse> getConsultaxPlacaMTCAsync(string arg0)
        {
            wsSoapSUNARP.getConsultaxPlacaMTCRequest inValue = new wsSoapSUNARP.getConsultaxPlacaMTCRequest();
            inValue.Body = new wsSoapSUNARP.getConsultaxPlacaMTCRequestBody();
            inValue.Body.arg0 = arg0;
            return ((wsSoapSUNARP.WSVehicularMtcDelegate)(this)).getConsultaxPlacaMTCAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.WSVehicularMtcPort))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.WSVehicularMtcPort))
            {
                return new System.ServiceModel.EndpointAddress("http://190.216.182.41/WSVehicular3Web/WSVehicularMtcService");
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return WSVehicularMtcDelegateClient.GetBindingForEndpoint(EndpointConfiguration.WSVehicularMtcPort);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return WSVehicularMtcDelegateClient.GetEndpointAddress(EndpointConfiguration.WSVehicularMtcPort);
        }
        
        public enum EndpointConfiguration
        {
            
            WSVehicularMtcPort,
        }
    }
}
