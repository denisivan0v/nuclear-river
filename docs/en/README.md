![](../media/nuclear-logo.png)
# NuClear River Documentation

> **Warning** This documentation is a work in progress.

**NuClear River** is a customizable platform to build [Read Model](http://codebetter.com/gregyoung/2010/02/15/cqrs-is-more-work-because-of-the-read-model/) in sense of [CQRS (Command Query Responsibility Segregation)](https://cqrs.files.wordpress.com/2010/11/cqrs_documents.pdf).

Did you ever had following issues?

* Data of your appication(s) is properly structured for create/update/delete commands, but read queries are (very) complicated
* You have different sets of read queries for one data structure to solve bussiness tasks in different fields. Or even more, you have different systems solving their own tasks reading the same data
* Read queries execution is slow
* Data structure changing often, so you have to update both read and write scenarios, even if you still have to read the same data
* You always need to find a balance between read and write queries when trying to optimize interactions with a data storage (e.g. indexes for SQL storages)

If so, you've already heard about CQRS and it's profits. NuClear River is the platform that makes your life with "Q" letter in CQRS abbreviation much easer.

Here is the big picture how NuClear River can be used in your environment:

![](diagrams/nuclear-river-big-picture.png)

Basically, all you need to build Read Model are events that generated as a result of commands execution in the the source system. Structure of these events may be different, but they must contain identities of entities that has been changed. In some cases they can contain detailed changes descriptions, but it is not necessary.

It is also important that you can build Read Model just for a specific bounded context of your domain. Structure of the data of resulting Read Model can be defined based on querying needs (e.g. denormalized) and can be totally different from the data structure in the source system where it was definded based on create/update/delete needs. 

The result that you achieve when using NuClear River - read and write stacks are separated and can be developed independenly, so it is a fast way to move to CQRS-way of application design in specific part of business logic (business processes) of your application(s).

There are some important terms here:

* Source system
* [Bounded context](http://martinfowler.com/bliki/BoundedContext.html)
* [Metadata descriptions](desing-overview/metadata-descriptions.md)
* [Querying](desing-overview/querying-design.md)
* [Replication](desing-overview/replication-design.md)
* Events (UseCases) processing
* Specification pattern

See [Terms](terms.md) chapter for details.

High-level design of NuClear River described in [the next chapter](desing-overview\README.md).