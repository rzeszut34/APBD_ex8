namespace APBD_ex6.Entities;

public class PCComponent
{
    public int PCId { get; set; }
    public string ComponentCode { get; set; } = string.Empty;
    public int Amount { get; set; }

    public PC PC { get; set; }
    public Component Component { get; set; }
}