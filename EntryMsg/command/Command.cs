using network;

namespace command;

internal class Command
{
    private string Name { get; set; }

    protected Command(string name)
    {
        this.Name = name;
    }

    public string GetName()
    {
        return Name;
    }

    public virtual void Handle(string[] args) {}

    protected List<Provider> Clients => EntryServer.Instance.Clients;
}