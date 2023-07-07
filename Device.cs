public class Device{
    private List<Port> _myPorts;
    private string _layer, _portCount;
    public Device(List<Port> myPorts, string layer, string portCount){
        _myPorts=myPorts;
        _layer=layer;
        _portCount=portCount;
    }
    public string CheckPortID(string value){
        foreach (var item in _myPorts)
        {
            string check = item.GetPortID();
            string whatIReturn = null;
            if(check!=null){
                whatIReturn = $"###DEVICE###|||{_layer}|||{_portCount}|||"+check;
            }
            return whatIReturn;
        }
        return null;
    }
    public string GetLayer(){ return _layer;}
    public string GetPortCount(){ return _portCount;}
    public List<Port> GetPorts(){ return _myPorts;}
}