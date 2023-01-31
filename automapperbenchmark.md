[Readme](./readme.md)

- [Simple Benchmark](./automappersimplebenchmark.md)
- [Composite Benchmark](./automappercompositebenchmark.md)

# AutoMapper Benchmark
I decided to review this benchmark because I realized my test was way too naive and instead of explaining what motivated me
to create this, I just made a couple of snarky, unhelpful comments. So I decided to revamp the whole thing.


## Motivation
While I like AutoMapper, I know that it's not perfect, but I've seen a couple of comments in the internet about how bad it is to use it
and that even the package's author recommends not using it for every single case.


### What is so bad about AutoMapper?
1. It tricks the static code analyzers. Since it uses reflection, it's not possible to know what properties are being mapped. 
Sometimes it will look like your model (or part of it) is not being used, but it's actually being used by AutoMapper.
2. When the mapping is done implicitly, it's not possible to navigate form the model to the entity.
3. Easy to break. If you change the name of a property in the entity, you will have to change it in the model as well. 
This is not a big deal, but it's easy to forget.
4. Breaks code organization/cleanliness. The business logic for converting entities lives inside a profile, somewhere in 
the application. This means that to test a conversion logic, you'll end up having to create loose helpers or test the whole profile.
Things can get even worse if you have multiple profiles and you need to test all of them.
5. Heavily depends on reflection.
6. Mapping errors happens at runtime and not compile-time. (I know the method `AssertConfigurationIsValid` exists to mitigate this, but it's not perfect.)


### What is so good about AutoMapper?
1. Greatly reduces the amount of "mindless code" and test you have to create when your project has hundreds of entities and models.
2. Simple/Clean way to map objects, especially if they have properties with the same name.
3. It's easy to use and it's very well documented.
4. The mapping can be easily reused throughout the application.


## How is this benchmark structured

I created two sets of benchmark:
1. [Simple](./automappersimplebenchmark.md): Tests the performance while converting an entity that has only primitive properties;
2. [Composite](./automappercompositebenchmark.md): Tests the performance while converting an entity that other entities as properties;

For both, I used a list of 1, 1000 and 10000 entities.

### Scenarios tested

1. Direct assignment (in a for loop and using LINQ): Assigning the properties of the entity to the model using a manual mapping. Just like cavemen did.
2. Implicit conversion (in a for loop and using LINQ): Using implicit conversion to convert the entity to the model.
3. Explicit conversion (in a for loop and using LINQ): Using explicit conversion to convert the entity to the model.
4. AutoMapper (in a for loop, using LINQ and batch converting): Using AutoMapper to convert the entity to the model.

The reason for using for loop and LINQ is basically because I wanted to see if there's any performance difference in 
those ways of iterating through a list. Also, I want to run this again using .net7 and see if there's any performance 
improvement for the LINQ version.

#### Methods

For both sets of benchmarks, I created the following methods:

1. DirectAssignment_ListConvertedInForLoop: Direct assignment of the properties of a single entity to the model using a for loop;
2. DirectAssignment_ListConvertedLINQ: Direct assignment of the properties of a single entity to the model using LINQ;
3. Explicit_ListConvertedInForLoop: Conversion of a single entity to model using explicit conversion in a for loop;
4. Explicit_ListConvertedLINQ: Conversion of a single entity to model using explicit conversion with LINQ;
5. Implicit_ListConvertedInForLoop: Conversion of a single entity to model using implicit conversion in a for loop;
6. Implicit_ListConvertedLINQ: Conversion of a single entity to model using implicit conversion with LINQ;
7. AutoMapper_ListConvertedInForLoop: Conversion of a single entity to model using AutoMapper in a for loop;
8. AutoMapper_ListConvertedLINQ: Conversion of a single entity to model using AutoMapper with LINQ;
9. AutoMapper_ListOfEntitiesConverted: Batch conversion of a list of entities to models using AutoMapper.


# Implicit/Explicit conversion
In C#, conversion operators are used to convert an object of one type to another.
There are two types of conversion operators: explicit and implicit.

Explicit conversion operators are used to perform conversions that may result in data
loss or may not be exactly representable. These conversions require a cast operator in
order to be performed. For example:
```csharp
double d = 12.34;
var i = (int)d;  // explicit conversion from double to int
```

Implicit conversion operators are used to perform conversions that will not result in data loss
and are exactly representable. These conversions do not require a cast operator and are
performed automatically by the compiler. For example:
```csharp
int i = 123;
long l = i;  // implicit conversion from int to long

```

One big difference between explicit and implicit conversion operators is that implicit allows for both
operations (implicit and explicit) while explicit only allows for explicit operations. This sentence seems kind
of nonsensical, but it's actually quite simple. If you implement implicit conversion, you can do both examples
listed above. But if you implement explicit conversion, you can only do the first example.

This implementation was made in the ProductModel class. This way we keep the business logic in the Entity class and the conversion logic in the Model.

# General results
For both benchmarks, the results were pretty consistent: Anything was faster than AutoMapper, which also consumed more memory.

One thing that really jumped out at me was the performance of explicitly converting individual entities in a for loop was way faster than telling 
AutoMapper to convert the whole at once.

Does this mean that we should stop using AutoMapper altogether? No. It's still a great tool and it's very useful when you have lots of entities to 
be converted and want to avoid writing a lot of mind numbing code. Maybe change the batch conversion to a for loop.

One thing that weights against using AutoMapper is that, by using an approach like implicit/explicit conversion, you make your code cleaner, 
more testable, easier to navigate and easier to refactor with a plus that you'll rely on one less Dependency Injection.

Don't take my word for it. Feel free to modify this benchmark to something closer to your use case and see if it makes sense to use AutoMapper or not.