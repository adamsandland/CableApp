public class FileManager{
    private List<Cable> _HouseCables = new List<Cable>();
    private List<Room> _HouseRooms = new List<Room>();
    private List<string> _myFile;
    public void OverwriteSave(string filepath){
        //program must write all items to a line
        List<string> filewrite = new List<string>();
        foreach (var item in _HouseCables)
        {
            filewrite.Add($"###CABLE###|||{item.GetDest()}|||{item.GetSrc()}");
        }
        foreach (var room in _HouseRooms)
        {
            List<Rack> room_racks = room.GetRacks(); 
            foreach (var rack in room_racks)
            {
                List<Device> rack_devices = rack.GetDevices();
                foreach (var device in rack_devices)
                {
                    List<Port> device_ports = device.GetPorts();
                    foreach (var port in device_ports)
                    {
                        filewrite.Add($"###PORT###|||{port.GetPortID()}");
                    }
                    filewrite.Add($"###DEVICE###|||{device.GetLayer()}|||{device.GetPortCount()}");
                }
                filewrite.Add($"###RACK###|||{rack.GetNumber()}|||{rack.GetLocation()}");
            }
            filewrite.Add($"###ROOM###|||{room.GetName()}|||{room.GetLocation()}");
        }
        //after writing all items to the list, go through and write to file.
        File.WriteAllLines(filepath,filewrite);
    }
    public void LoadSave(string filepath){
        //program must convert myFile to a list of strings, one string for each line.
        _myFile = File.ReadAllLines(filepath).ToList();
    }
    public void CreateBackup(string filepath){
        //program must duplicate the current save and change it to type .bak
    }
    public void SaveToCloud(){

    }
    public List<Cable> GetCableList(){ return _HouseCables; }
    public List<Room> GetRoomList(){ return _HouseRooms; }
    public void ReadFileList(){
        List<Cable> TempList = new List<Cable>();
        string marker="cable";
        List<Port> TempPort = new List<Port>();
        List<Device> TempDevice = new List<Device>();
        List<Rack> TempRack = new List<Rack>();
        List<Room> TempRoom = new List<Room>();
        foreach (var line in _myFile)
        {
            switch(GetDataType(line)){
                case "cable":
                    string destination = line.Split("|||")[1];
                    string source = line.Split("|||")[2];
                    string cableType = line.Split("|||")[3];
                    TempList.Add(new Cable(destination, source, cableType));
                    break;
                case "room":
                    if(marker!="room"){
                        marker="room";
                        string RoomName = line.Split("|||")[1];
                        string RoomLocation = line.Split("|||")[2];
                        TempRoom.Add(new Room(TempRack,RoomName,RoomLocation));
                        TempRack = new List<Rack>();
                    }
                    break;
                case "rack":
                    if(marker!="rack"){
                        marker="rack";
                        string RackNumber = line.Split("|||")[1];
                        string RackLocation = line.Split("|||")[2];
                        TempRack.Add(new Rack(TempDevice,RackNumber,RackLocation));
                        TempDevice = new List<Device>();
                    }
                    break;
                case "device":
                    if(marker!="device"){
                        marker="device";
                        string DeviceLayer = line.Split("|||")[1];
                        string DevicePortCount = line.Split("|||")[2];
                        TempDevice.Add(new Device(TempPort, DeviceLayer, DevicePortCount));
                        TempPort = new List<Port>();
                    }
                    break;
                case "port":
                    if(marker!="port"){
                        marker="port";
                    }
                    string PortId=line.Split("|||")[1];
                    TempPort.Add(new Port(PortId));
                    break;
            }
        }
        _HouseCables=TempList;
        _HouseRooms=TempRoom;
    }
    private string GetDataType(string line){
        if(line.Contains("###CABLE###")){
            return "cable";
        }else if(line.Contains("###ROOM###")){
            return "room";
        }else if(line.Contains("###RACK###")){
            return "rack";
        }else if(line.Contains("###DEVICE###")){
            return "device";
        }else if(line.Contains("###PORT###")){
            return "port";
        }
        return null;
    }
    public List<string> GetFile(){
        return _myFile;
    }
}