public class Port{
    private string _PortID;
    private bool _highlight;
    public Port(string PortID){
        _PortID=PortID;
    }
    public string GetPortID(){ return _PortID; }
    public void Highlight(bool set){ _highlight=set; }
    public bool IsHighlighted(){ return _highlight; }
}