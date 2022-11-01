# Thoughts...

Your first impression might be - wow, there's a lot of code in here.  Ok, maybe, but...

There are some important things to think about in here.  Everyone talks about DDD, etc. but there has to be an entry point.  You have a Customer entity, but something has to load that thing and something has to call methods on it.  What made the big bang?  This is where DDD kinda gets flipped on it's ear in a sense.

The Service classes are just POCO's with discrete inputs and outputs with a common execution pattern (`.Execute()`).  They have a strict validation pattern so that the inputs are validated prior to Execute.  They load and interact with entities and do stuff.  As much of the hard logic is pushed to entities where it's appropriate.

This fictitious example is based on a few things:

* Customer is first created in `Created` status
* Customer's in `Created` status can move to `Activated`, `Deactivated`, or `Suspended`
* Each of these are different Services and act on Customer differently
* Pay attention to the validators!