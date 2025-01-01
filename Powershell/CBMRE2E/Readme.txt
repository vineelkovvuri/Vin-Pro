Q. What is this project for?
A. It automates the execution of CBMR E2E on Hyper-V.

Q. How does it perform CBMR E2E?
A. Below are the steps.
    1. Read an Configs\*.xml and capture branch and endpoint information
    2. Identify the \\winbuilds build that is published to DCAT for the chosen branch
    3. Create a new VM with that build
        3a. Inject unattended.xml(with has an in built admin account)
    4. Wait for the VM to be launched to Desktop
    5. Use powershell direct to run commands with in the VM. Here we run si capture command
        5a. Copy the captured si from the VM to local machine(Handy for hardware testing)
    6. Shutdown the VM. Change the boot order to pick up the UEFI shell vhd
    7. Power on the VM to initiate CBMR E2E.
    8. If it fails in UEFI. Turn off the VM and collect the UEFI logs with the VM screenshot to \\ffucore
    9. If it fails in StubOS. Collect the StubOS logs with the VM screenshot to \\ffucore

Q. How do I run the project?
A. Copy the project and inside powershell run .\cbmr.ps1

Q. How do I know if CBMR E2E for a build succeeded or failed?
A. An email will be sent appropriately with failed logs and VM screenshot attached!

Q. What are Configs\*.xml?
A. These are the xml files that describe what branch should be used to pick a
build to perform CBMR E2E. They contain below info
        <cbmr>
        <!-- Build and Branch info -->
        <build></build> <!-- 22518.1000.211203-1458 If this is empty, A DCAT published build is picked -->
        <branch>ni_release</branch>
        <endpointtype>ppe</endpointtype>

        <!-- Standard endpoints -->
        <ppeendpoint>https://glb.cws-int.dcat.dsp.mp.microsoft.com/UpdateMetadataService/updates/search/v1/bydeviceinfo/</ppeendpoint>
        <prodendpoint>https://fe3.delivery.mp.microsoft.com:443/UpdateMetadataService/updates/search/v1/bydeviceinfo/</prodendpoint>

        <!-- Parameters to spawn a new VM -->
        <vmconfigpath>C:\Hyper-V\VirtualMachines</vmconfigpath>
        <memory>8GB</memory>
        <cores>4</cores>

        <!-- Other miscellaneous parameters -->
        <emailto>abc@microsoft.com</emailto> <!-- change this to your email id -->
        <logpath>\\ffucore\public\vineelko\cbmr\Logs\DailyRuns</logpath>
        </cbmr>

The important info in the xml is <branch> and <endpointtype>. In order perform
E2E on a new branch simply author a new xml and associated cbmr_config.txt!




