using System.Collections.Generic;
using HomematicCore.Homematic.Daemon;
using HomematicCore.Homematic.Daemon.Domain;

namespace HomematicCore.Manager.Web.ViewModels
{
    public class ParameterDialogViewModel : DialogViewModelBase
    {
        private readonly IHomematicDaemon _homematicDaemon;

        public string ParameterSetKey { get; private set; }

        public string Address { get; private set; }

        public List<ParameterViewModel> Parameters { get; private set; }

        public ParameterDialogViewModel(IHomematicDaemon homematicDaemon)
        {
            _homematicDaemon = homematicDaemon;
            Parameters = new List<ParameterViewModel>();
        }

        public void OpenParameterDialog(string address, string parameterSetKey)
        {
            Address = address;
            ParameterSetKey = parameterSetKey;
            LoadParameterSet();
            
            OnOpenRequested();
        }

        public void LoadParameterSet()
        {
            var parameterSetDescriptions = _homematicDaemon.GetParameterSetDescription(Address, ParameterSetKey);
            var parameterSets = _homematicDaemon.GetParameterSet(Address, ParameterSetKey);

            Parameters.Clear();

            foreach (var key in parameterSetDescriptions.Keys) 
            {
                var setDescription = parameterSetDescriptions[key];
                ParameterViewModel parameter; 

                switch (setDescription.ParameterType)
                {
                    case ParameterTypes.Integer:
                    case ParameterTypes.Enum:
                        parameter = new ParameterViewModel<int?>();
                        break;
                    case ParameterTypes.Float:
                        parameter = new ParameterViewModel<double?>();
                        break;
                    case ParameterTypes.String:
                        parameter = new ParameterViewModel<string>();
                        break;
                    case ParameterTypes.Bool:
                    case ParameterTypes.Action:
                        parameter = new ParameterViewModel<bool?>();
                        break;
                    default:
                        parameter = new ParameterViewModel();
                        break;
                }

                parameter.Name = key;
                parameter.DefaultValue = setDescription.DefaultValue;
                parameter.Value = parameterSets.GetValue(key);

                Parameters.Add(parameter);
            }
        }

        public void UploadParameter(ParameterViewModel parameter)
        {
            _homematicDaemon.SetValue(Address, parameter.Name, parameter.Value);
        }

        public void UploadParameterSet()
        {
            var parameterSet = new ParameterSet();

            foreach (var parameter in Parameters) 
            {
                parameterSet.Add(parameter.Name, parameter.Value);
            }

            _homematicDaemon.PutParamset(Address, ParameterSetKey, parameterSet);
        }

        public void Close()
        {
            OnCloseRequested();
        }
    }
}
