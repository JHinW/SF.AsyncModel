"# ServiceFabric.AsyncModel" 

I'm now trying to construct a distributed Architecture which treats Micro-Service as a middleware, message will be enqueued to a reliable queue and notify the sender when the message processing is finished.  

# Inspiration  
 1. Event Loop  
 1.1. The event loop from [nodejs](https://nodejs.org/en/docs/guides/event-loop-timers-and-nexttick/) explained that the process will keep polling for the inputed scripts, callbacks are excuted when the event data is grabbed.  
 1.2. In service fabric polling is already exsiting in Stateful micro-service.  

2. Async  Notification  
2.1. Async notificaiton will do non-blocking action which just means the event message wil be pushed into an another(or the orignal queue) again,
you may understand what the "again" means: loop is everywhere.   
2.2. Thanks to the class `Taskcompeletionsource<T>`, we can do async nitification very easily.

3. Immutable  
3.1. I learned it from [Redux](http://redux.js.org/): do not try to mutate an object, if necessary, just create a new one.  
3.2. Each tutorial will tell you that immutabe set(dictionary, list, map) is thread-safe, to me, it just make debugging code easily as changes are always not in the current reference.(I'm a beginner.)

4. Middleware in Asp.Net Core  
4.1.  Aspnet core process HttpContext in middlware, if you have read the [source code](https://github.com/aspnet/HttpAbstractions/blob/594f55947f4c1d0a9d3122e3f39bcfa81199b12a/src/Microsoft.AspNetCore.Http/Internal/ApplicationBuilder.cs#L80) of Aspnet core, you will find middlware is abstracted as a deleagte.  
4.2. you may enjoy the design of this kind of middleware because functional programming(curry, function compose) can make middleware more extendable.

# Get started

**Design**  

If you want to create a modularized app and minimize the dependencies between the different parts of your application, Dependency Injection is a good chioce.

I built a DI of my own: 

![DI image](/resources/compiler.png)


Functional expression:
```csharp
   compiler = () =>{
       return compiler[] => Type => instance;
   }
```

How to use EasyDI:
```csharp
            
        var box = new EasyTypeContainer();
        box.AddDisp<IClassA>(new ClassA());
        box.AddDisp<IClassB>(typeof(ClassB));
        box.AddDisp<IClassC, ClassC>();
        box.AddDisp<IClassD>( factory => {
            var para = (IClassC)factory.GetInstance(typeof(IClassC));
            var intance =  new ClassD(para);
            return intance;
        });

        box.AddDisp<ClassE, ClassE>();
        var tracker = box.CreateTracker();
        var result = tracker.Track(typeof(ClassE));

```