#### Sample Builder
#### Author: Alex Soto alex.soto@xamarin.com

MDTOOL=/Applications/Xamarin\ Studio.app/Contents/MacOS/mdtool
PROJECTS=\
	TSMiniWebBrowserSample/TSMiniWebBrowserSample.sln \
	TSMiniWebBrowserSample/TSMiniWebBrowserSample-Classic.sln \
	TSMiniWebBrowserSample/TSMiniWebBrowserSample-Component.sln \
	TSMiniWebBrowserSample/TSMiniWebBrowserSample-Classic-Component.sln \

all:
	for i in $(PROJECTS); do ($(MDTOOL) build -c:"Release|iPhone" $$i); done
	
clean:
	for i in $(PROJECTS); do ($(MDTOOL) build -c:"Release|iPhone" -t:Clean $$i); done
