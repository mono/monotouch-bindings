These drivers still require that you add the command line options to link properly
with the native library.

Flags
=====

Set your mtouch extra options to:

	-gcc_flags "-L${ProjectDir} -lgebeprinter -force_load ${ProjectDir}/libgebeprinter.a"

At least one user has reported that you must also set LLVM armv6/armv7 support
for the bindings to work.   This will depend on which binaries the upstream provider
is shipping.
