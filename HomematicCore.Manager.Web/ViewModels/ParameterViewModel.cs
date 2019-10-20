
namespace HomematicCore.Manager.Web.ViewModels
{
    public class ParameterViewModel
    {
        public string Name { get; set; }

        public object DefaultValue { get; set; }
        
        public virtual object Value { get; set; }
    } 

    public class ParameterViewModel<T> : ParameterViewModel
    {   
        public new T Value 
        {
            get => (T) base.Value;
            set => base.Value = value;
        }
    }
}