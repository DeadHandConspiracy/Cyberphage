Cyberphage Dir tree
├── Assets/          # Shared Images and Icons
├── D Lang/          # Shared D code
│
├── Linux/           # C++ code
│   ├── main.cpp
│   ├── Part1/
│   │   └── p1.cpp
│   ├── Part2/
│   │   └── p2.cpp
│   │ 
│   └── Makefile	 # Builds the Linux executable and desktop environment
│
├── Windows/
│   ├── Cyberphage/
│   │   └── App.xaml			# Declarative starting point of a WPF application
│   │   └── App.xaml.cs			# Code-behind file for App.xaml
│   │   └── Assemblyinfo.cs 		# Assembly-level metadata attributes
│   │   └── Cyberphage.csproj		# C# Project File
│   │   └── MainWindow.xaml		# Main Cyberphage GUI Window
│   │   └── MainWindow.xaml.cs		# Code-behind file for MainWindow.xaml
│   │
│   └── Build.bat	  # Builds the Windows executable and desktop environment
│
├── bin/              # Final executable
└── Build.cmd		  # Polyscript for Windows and Linux
