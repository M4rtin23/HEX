#!/bin/sh
cp -r '../bin/Debug/netcoreapp3.1/linux-x64/publish' './imahex/usr/lib/imahex'
dpkg-deb --build imahex
rm -r './imahex/usr/lib/imahex'
