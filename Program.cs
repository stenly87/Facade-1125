// See https://aka.ms/new-console-template for more information
// паттерн Фасад
// структурный паттерн
// позволяет инкапсулировать работу с несколькими системами
// и упростить вызов на исполнение данной работы
// т.е. например существует несколько объектов, которые работают
// во взаимосвязи друг с другом и существует четкий алгоритм
// их взаимодействия. В этом случае вместо того, чтобы каждый 
// раз прописывать этот алгоритм взаимодействия, можно создать
// фасад, который инкапсулирует нужную логику и объекты
ClientFacade clientFacade = new ClientFacade(new WorkerProrab(),
    new WorkerBuilder(), new Crane());
clientFacade.BuildHouse();  // для клиента работа крана, прораба и строителя инкапсулирована в фасад и легко используется

// фасад инкапсулирует взаимодействие вложенных объектов
public class ClientFacade
{
    private readonly WorkerProrab workerProrab;
    private readonly WorkerBuilder workerBuilder;
    private readonly Crane crane;

    public ClientFacade(WorkerProrab workerProrab, 
        WorkerBuilder workerBuilder,
        Crane crane)
    {
        this.workerProrab = workerProrab;
        this.workerBuilder = workerBuilder;
        this.crane = crane;
    }

    public void BuildHouse()
    {
        // здесь может быть большой и сложный разветвленный
        // алгоритм взаимодействия имеющихся объектов
        workerProrab.Scream();
        crane.Work();
        workerProrab.Scream();
        workerBuilder.Build();
        workerProrab.Scream();
    }
}

public class Crane
{
    internal void Work()
    {
        Console.WriteLine("Кран поднимает грузы");
    }
}

public class WorkerBuilder
{
    internal void Build()
    {
        Console.WriteLine("Строитель строит стены");
    }
}

public class WorkerProrab
{
    internal void Scream()
    {
        Console.WriteLine("Прораб орет на строителя и на кран");
    }
}