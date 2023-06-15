using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;
using Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities.Classes;
using Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities.Records;

namespace Raccoon.Ninja.Application.Benchmarks.Benchmarks;

[ExcludeFromCodeCoverage]
[MemoryDiagnoser, MinColumn, MaxColumn, MeanColumn, MedianColumn, UnicodeConsoleLogger]
public class RecordVsClassBenchmarks
{
    [Benchmark]
    public void Record_Instantiate()
    {
        var person = new Person(Guid.NewGuid(), "John Doe", DateTime.Now, true, 100, DateTime.Now);
    }

    [Benchmark]
    public void Class_Instantiate()
    {
        var person = new PersonClass
        {
            Id = Guid.NewGuid(),
            Name = "John Doe",
            BirthDate = DateTime.Now,
            IsActive = true,
            RewardPoints = 100,
            LastAccessed = DateTime.Now
        };
    }

    [Benchmark]
    public void RecordStruct_Instantiate()
    {
        var person = new PersonRecordStruct(Guid.NewGuid(), "John Doe", DateTime.Now, true, 100, DateTime.Now);
    }

    [Benchmark]
    public void Struct_Instantiate()
    {
        var person = new PersonStruct
        {
            Id = Guid.NewGuid(),
            Name = "John Doe",
            BirthDate = DateTime.Now,
            IsActive = true,
            RewardPoints = 100,
            LastAccessed = DateTime.Now
        };
    }
    
    [Benchmark]
    public void Record_Copy_With_Modified_Property()
    {
        var person = new Person(Guid.NewGuid(), "John Doe", DateTime.Now, true, 100, DateTime.Now);

        var newPerson = person with { Name = "Jane Doe" };
    }

    [Benchmark]
    public void Class_Copy_With_Modified_Property()
    {
        var person = new PersonClass
        {
            Id = Guid.NewGuid(),
            Name = "John Doe",
            BirthDate = DateTime.Now,
            IsActive = true,
            RewardPoints = 100,
            LastAccessed = DateTime.Now
        };

        var newPerson = new PersonClass
        {
            Id = person.Id,
            Name = "Jane Doe",
            BirthDate = person.BirthDate,
            IsActive = person.IsActive,
            RewardPoints = person.RewardPoints,
            LastAccessed = person.LastAccessed
        };
    }

    [Benchmark]
    public void RecordStruct_Copy_With_Modified_Property()
    {
        var person = new PersonRecordStruct(Guid.NewGuid(), "John Doe", DateTime.Now, true, 100, DateTime.Now);

        var newPerson = person with { Name = "Jane Doe" };
    }

    [Benchmark]
    public void Struct_Copy_With_Modified_Property()
    {
        var person = new PersonStruct
        {
            Id = Guid.NewGuid(),
            Name = "John Doe",
            BirthDate = DateTime.Now,
            IsActive = true,
            RewardPoints = 100,
            LastAccessed = DateTime.Now
        };

        var newPerson = person with { Name = "Jane Doe" };
    }
    
    [Benchmark]
    public void Record_Compare_Values()
    {
        var person = new Person(Guid.NewGuid(), "John Doe", DateTime.Now, true, 100, DateTime.Now);

        var newPerson = person with { Name = "Jane Doe" };

        var isEqual = person == newPerson;
    }

    [Benchmark]
    public void Class_Compare_Values()
    {
        var person = new PersonClass
        {
            Id = Guid.NewGuid(),
            Name = "John Doe",
            BirthDate = DateTime.Now,
            IsActive = true,
            RewardPoints = 100,
            LastAccessed = DateTime.Now
        };

        var newPerson = new PersonClass
        {
            Id = person.Id,
            Name = "Jane Doe",
            BirthDate = person.BirthDate,
            IsActive = person.IsActive,
            RewardPoints = person.RewardPoints,
            LastAccessed = person.LastAccessed
        };

        var isEqual = person.Equals(newPerson);
    }

    public void RecordStruct_Compare_Values()
    {
        var person = new PersonRecordStruct(Guid.NewGuid(), "John Doe", DateTime.Now, true, 100, DateTime.Now);

        var newPerson = person with { Name = "Jane Doe" };

        var isEqual = person == newPerson;
    }

    [Benchmark]
    public void Struct_Compare_Values()
    {
        var person = new PersonStruct
        {
            Id = Guid.NewGuid(),
            Name = "John Doe",
            BirthDate = DateTime.Now,
            IsActive = true,
            RewardPoints = 100,
            LastAccessed = DateTime.Now
        };

        var newPerson = person with { Name = "Jane Doe" };
        
        var isEqual = person.Equals(newPerson);
    }
    
    [Benchmark]
    public void Record_ToString()
    {
        var person = new Person(Guid.NewGuid(), "John Doe", DateTime.Now, true, 100, DateTime.Now);

        var personString = person.ToString();
    }

    [Benchmark]
    public void Class_ToString()
    {
        var person = new PersonClass
        {
            Id = Guid.NewGuid(),
            Name = "John Doe",
            BirthDate = DateTime.Now,
            IsActive = true,
            RewardPoints = 100,
            LastAccessed = DateTime.Now
        };

        var personString =
            $"{{Id: {person.Id}, Name: {person.Name}, BirthDate: {person.BirthDate}, IsActive: {person.IsActive}, RewardPoints: {person.RewardPoints}, LastAccessed: {person.LastAccessed}}}";
    }

    [Benchmark]
    public void RecordStruct_ToString()
    {
        var person = new PersonRecordStruct(Guid.NewGuid(), "John Doe", DateTime.Now, true, 100, DateTime.Now);

        var personString = person.ToString();
    }

    [Benchmark]
    public void Struct_ToString()
    {
        var person = new PersonStruct
        {
            Id = Guid.NewGuid(),
            Name = "John Doe",
            BirthDate = DateTime.Now,
            IsActive = true,
            RewardPoints = 100,
            LastAccessed = DateTime.Now
        };

        var personString =
            $"{{Id: {person.Id}, Name: {person.Name}, BirthDate: {person.BirthDate}, IsActive: {person.IsActive}, RewardPoints: {person.RewardPoints}, LastAccessed: {person.LastAccessed}}}";
    }
    
    [Benchmark]
    public void Record_Deconstruct()
    {
        var person = new Person(Guid.NewGuid(), "John Doe", DateTime.Now, true, 100, DateTime.Now);

        //Deconstruct Person
        var (id, name, birthDate, isActive, rewardPoints, lastAccessed) = person;
    }

    [Benchmark]
    public void Class_Deconstruct()
    {
        var person = new PersonClass
        {
            Id = Guid.NewGuid(),
            Name = "John Doe",
            BirthDate = DateTime.Now,
            IsActive = true,
            RewardPoints = 100,
            LastAccessed = DateTime.Now
        };

        //Deconstruct Person
        var id = person.Id;
        var name = person.Name;
        var birthDate = person.BirthDate;
        var isActive = person.IsActive;
        var rewardPoints = person.RewardPoints;
        var lastAccessed = person.LastAccessed;
    }
    
    [Benchmark]
    public void RecordStruct_Deconstruct()
    {
        var person = new PersonRecordStruct(Guid.NewGuid(), "John Doe", DateTime.Now, true, 100, DateTime.Now);

        //Deconstruct Person
        var (id, name, birthDate, isActive, rewardPoints, lastAccessed) = person;
    }

    [Benchmark]
    public void Struct_Deconstruct()
    {
        var person = new PersonStruct
        {
            Id = Guid.NewGuid(),
            Name = "John Doe",
            BirthDate = DateTime.Now,
            IsActive = true,
            RewardPoints = 100,
            LastAccessed = DateTime.Now
        };

        //Deconstruct Person
        var id = person.Id;
        var name = person.Name;
        var birthDate = person.BirthDate;
        var isActive = person.IsActive;
        var rewardPoints = person.RewardPoints;
        var lastAccessed = person.LastAccessed;
    }
}