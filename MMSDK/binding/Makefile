BTOUCH=/Developer/MonoTouch/usr/bin/btouch
VERSION=1.0
all: MMAdView.dll

#Please do not remove libMMSDK_4.5.5.a check
libMMSDK_4.5.5.a:
	@if test -f ../../../monotouch-bindings-externals/MMSDK/libMMSDK_4.5.5.a; then \
		cp ../../../monotouch-bindings-externals/MMSDK/libMMSDK_4.5.5.a .; \
	else \
		echo "Please download libMMSDK_4.5.5.a from http://docs.millennialmedia.com/iOS-SDK/"; \
		open http://docs.millennialmedia.com/iOS-SDK/; \
	fi

MMAdView.dll: Makefile AssemblyInfo.cs MMAd.cs enums.cs libMMSDK_4.5.5.a
	$(BTOUCH) -e MMAd.cs AssemblyInfo.cs enums.cs --out=$@ --link-with=libMMSDK_4.5.5.a,libMMSDK_4.5.5.a

clean:
	-rm -f *.a *.dll
