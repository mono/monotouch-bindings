These are the bindings to ShareKit

The bindings are not as easy to use as they should be, because ShareKit suffers from a
number of problems:

	* ShareKit is not shipped as a library, but as a set of source files that 
	  you should link with (Easy to solve for an enterprising contributor).

	* ShareKit is designed to be configured with a set of keys at compile time
	  for sharing properties (you plug your twitter keys in the source code
	  directly and then build your binary)

ShareKit is not actively maintained, there is a very large list of issues reported
and pending patches as well as out of date instructions on how to use ShareKit, so
these bindings will suffer from all of the upstream limitations.
	
