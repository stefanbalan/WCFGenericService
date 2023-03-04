# WCFGenericService

My answer to [this](https://stackoverflow.com/q/48235538/1187199) question on stackoverflow.

>I have a large .NET 4.5 class library containing 60+ classes and many public methods. This works as a programmatic interface to my app. Now I would like to invoke this library over the network using WCF. What are the best practices to do this?
>
>A naïve approach would be to wrap my class library with a WCF service library that replicates the class and method structure of the original class library, having one method for each method in it. However, this seems to be overkill and go against the principle to make chunky rather than chatty network interfaces. How should I construct the WCF service library then? What structure should it have? Is there any recognised best practice guidance on this? Thanks.

1. I was gonna mention parameter validation, but then I went ahead and done it, using reflection to validate count and object parameter can be converted.
2. Then I thought of complex objects... Yes, they can be sent as object in the parameter array (and they get validated correctly by the above), but they need to be exposed by the service. To include an unused class in the service definition use `ServiceKnownType` attribute.
3. Having this kind of service definition opens a whole new level of opportunity (for chaos! :)) You can add values to the end of the Operation enum on the server and not break the client. Or use a string for the operation code (and not use complex types as parameters, see 2.) and go wild!!! Multiple versions of servers negotiating with multiple versions of clients, partial server implementations... become possible, obviously requiring some versioning and discovery logic (on a central service?)

In conclusion: I got a little carried away at 3. above, and what I'm describing there must be the exact opposite of a best practice for WCF services. If I'm not mistaken, the fact that changing the server breaks the clients is considered one of the advantages of WCF. But I'd still consider the above solution as valid for some scenarios like

    1. quickly wrapping in a service a large library that doesn't change or that the clients don't mind not always getting a response from

    2. allowing for some degree of flexibility when clients are numerous and cannot be updated quickly so different versions need to work in parallel.
