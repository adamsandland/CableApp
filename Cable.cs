public class Cable{
    private string _sourcePort, _receiverPort, _cableType;
    public Cable(string sourcePort, string receiverPort, string cableType){
        _sourcePort=sourcePort;
        _receiverPort=receiverPort;
        _cableType=cableType;
    }
    public string CompareID(string ID){
        if(ID==_sourcePort){
            return _receiverPort;
        }else if(ID==_receiverPort){
            return _sourcePort;
        }else{
            return null;
        }
    }
    public string GetDest(){ return _receiverPort;}
    public string GetSrc(){ return _sourcePort;}
}