using System;
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
            var parameterDescriptions = _homematicDaemon.GetParameterSetDescription(Address, ParameterSetKey);
            var parameters = _homematicDaemon.GetParameterSet(Address, ParameterSetKey);

            Parameters.Clear();

            foreach (var description in parameterDescriptions) 
            {
                Parameters.Add(new ParameterViewModel
                {
                    Name = description.Key,
                    DefaultValue = description.Value.DefaultValue,
                    Unit = description.Value.Unit,
                    Value = parameters.GetValue(description.Key),
                    ValueList = description.Value.ValueList,
                    ParameterType = description.Value.ParameterType
            });
            }
        }

        private Dictionary<string, int?> ConvertValueList(string[] valueList)
        {
            var possibleValues = new Dictionary<string, int?>();

            if (valueList != null)
            {
                for (var i = 0; i < valueList.Length; i++)
                {

                }
            }
            return possibleValues;
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
