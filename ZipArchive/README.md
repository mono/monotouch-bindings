Monotouch bindings for ZipArchive
=================================

This library allows you to easily compress files to a Zip File.

You can get the ZipArchive source code from their [google code page](http://code.google.com/p/ziparchive/).

Building
========

To build the bindings, run the `make` command from within the bindings
directory form terminal and add 'ZipArchive.dll' to your project.

Usage
=====

To zip files:

      var zipFile = new MTZipArchive.ZipArchive();
      zipFile.CreateZipFile("/path/to/zip/file.zip");
      zipFile.AddFile("/path/of/file/to/compress.txt", "somefile.txt");
      // add more files as needed
      zipFile.CloseZipFile();

To unzip files:

      var zipFile = new MTZipArchive.ZipArchive();
      zipFile.UnzipOpenFile("/path/to/zip/file.zip");
      zipFile.UnzipFileTo("/location/to/unzip", true);
      zipFile.UnzipCloseFile();