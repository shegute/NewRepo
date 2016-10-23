﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Repositories.Service.PersonServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PersonServiceReference.IPersonService")]
    public interface IPersonService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/GetData", ReplyAction="http://tempuri.org/IPersonService/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/GetData", ReplyAction="http://tempuri.org/IPersonService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IPersonService/GetDataUsingDataContractResponse")]
        PersonService.CompositeType GetDataUsingDataContract(PersonService.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IPersonService/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<PersonService.CompositeType> GetDataUsingDataContractAsync(PersonService.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/GetPeople", ReplyAction="http://tempuri.org/IPersonService/GetPeopleResponse")]
        System.Collections.Generic.List<Repositories.Person> GetPeople();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/GetPeople", ReplyAction="http://tempuri.org/IPersonService/GetPeopleResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Repositories.Person>> GetPeopleAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/GetPerson", ReplyAction="http://tempuri.org/IPersonService/GetPersonResponse")]
        Repositories.Person GetPerson(string lastName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/GetPerson", ReplyAction="http://tempuri.org/IPersonService/GetPersonResponse")]
        System.Threading.Tasks.Task<Repositories.Person> GetPersonAsync(string lastName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/AddPerson", ReplyAction="http://tempuri.org/IPersonService/AddPersonResponse")]
        void AddPerson(Repositories.Person newPerson);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/AddPerson", ReplyAction="http://tempuri.org/IPersonService/AddPersonResponse")]
        System.Threading.Tasks.Task AddPersonAsync(Repositories.Person newPerson);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/UpdatePerson", ReplyAction="http://tempuri.org/IPersonService/UpdatePersonResponse")]
        void UpdatePerson(string lastName, Repositories.Person updatedPerson);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/UpdatePerson", ReplyAction="http://tempuri.org/IPersonService/UpdatePersonResponse")]
        System.Threading.Tasks.Task UpdatePersonAsync(string lastName, Repositories.Person updatedPerson);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/DeletePerson", ReplyAction="http://tempuri.org/IPersonService/DeletePersonResponse")]
        void DeletePerson(string lastName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/DeletePerson", ReplyAction="http://tempuri.org/IPersonService/DeletePersonResponse")]
        System.Threading.Tasks.Task DeletePersonAsync(string lastName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/UpdatePeople", ReplyAction="http://tempuri.org/IPersonService/UpdatePeopleResponse")]
        void UpdatePeople(System.Collections.Generic.List<Repositories.Person> updatedPeople);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/UpdatePeople", ReplyAction="http://tempuri.org/IPersonService/UpdatePeopleResponse")]
        System.Threading.Tasks.Task UpdatePeopleAsync(System.Collections.Generic.List<Repositories.Person> updatedPeople);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPersonServiceChannel : Repositories.Service.PersonServiceReference.IPersonService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PersonServiceClient : System.ServiceModel.ClientBase<Repositories.Service.PersonServiceReference.IPersonService>, Repositories.Service.PersonServiceReference.IPersonService {
        
        public PersonServiceClient() {
        }
        
        public PersonServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PersonServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PersonServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PersonServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public PersonService.CompositeType GetDataUsingDataContract(PersonService.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<PersonService.CompositeType> GetDataUsingDataContractAsync(PersonService.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public System.Collections.Generic.List<Repositories.Person> GetPeople() {
            return base.Channel.GetPeople();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Repositories.Person>> GetPeopleAsync() {
            return base.Channel.GetPeopleAsync();
        }
        
        public Repositories.Person GetPerson(string lastName) {
            return base.Channel.GetPerson(lastName);
        }
        
        public System.Threading.Tasks.Task<Repositories.Person> GetPersonAsync(string lastName) {
            return base.Channel.GetPersonAsync(lastName);
        }
        
        public void AddPerson(Repositories.Person newPerson) {
            base.Channel.AddPerson(newPerson);
        }
        
        public System.Threading.Tasks.Task AddPersonAsync(Repositories.Person newPerson) {
            return base.Channel.AddPersonAsync(newPerson);
        }
        
        public void UpdatePerson(string lastName, Repositories.Person updatedPerson) {
            base.Channel.UpdatePerson(lastName, updatedPerson);
        }
        
        public System.Threading.Tasks.Task UpdatePersonAsync(string lastName, Repositories.Person updatedPerson) {
            return base.Channel.UpdatePersonAsync(lastName, updatedPerson);
        }
        
        public void DeletePerson(string lastName) {
            base.Channel.DeletePerson(lastName);
        }
        
        public System.Threading.Tasks.Task DeletePersonAsync(string lastName) {
            return base.Channel.DeletePersonAsync(lastName);
        }
        
        public void UpdatePeople(System.Collections.Generic.List<Repositories.Person> updatedPeople) {
            base.Channel.UpdatePeople(updatedPeople);
        }
        
        public System.Threading.Tasks.Task UpdatePeopleAsync(System.Collections.Generic.List<Repositories.Person> updatedPeople) {
            return base.Channel.UpdatePeopleAsync(updatedPeople);
        }
    }
}
