Post
----
So the theory is that people like long function names in OO, I hate such function names and have sympathy for such people. I know a fellow developer who just wrote a function name and it's length was 120+ characters. Yeah, we live in such times where people have function names that can span 2 lines; a long walk from 'atoi' in C and 'abs' in lisp.

The function she was writing was a test function; most developers treat test functions with derision. Well, I don't. I like test functions they tell me what's the state of the current requirements from clients. When all the requirements from clients when are written in code in the form of tests, we can be sure that we have covered everything. Though the type of testing I believe in is self-testing and not passive run-the-test-to-see-if-application-is-okay-testing, but more about that at some point in future.

So, read the sampleTest.cs file and find out what's wrong, of course the function name don't make sense, but you will get the gist of it. Long function names are as bad as the terse ones. But people have come up with a lot of verbiage saying that some utilities help us when we have long and descriptive function names. One of such utility tool is teamcity, so you are running tests in teamcity and it fails, then teamcity will comeup with the function name that errored; and your problem is solved.

But I have better solution. Get a descrition attribute for the function and reduce the function name length. There are following problems though with this approach:

1. Not every language has a way to write code descriptively/decoratively (i.e. using attributes) because they don't have attributes.
2. We need to know when a function failed, so that we can execute a decoration.
3. For these things, all the languages and frameworks and tooools (there are a ton of these) need modification, which ain't happening in next 2 decades.
4. Even the languages that support code decorations (attributes) like C#, the process I am proposing that we all should follow is still difficult because some things are still missing.

Anyway, past the problems here's the process:

1. Create an attribute for the method that will contain the description of the methods scope. It's better than a mere comment as it's code and not a passive string that will be stripped away by compiler.
2. Shorten the function name and add description for it.
3. Find a way to know when the function has failed and report back the description then.
