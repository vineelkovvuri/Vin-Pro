



    //
    // When a virtual(in storage spaces parlance) disk(s) is surfaced by storage
    // spaces, It is exposed to storage VDS(via VDS_QUERY_SOFTWARE_PROVIDERS) as
    // a normal disk(but with a new disk number) and the original disks(both
    // physical and vhd disks) backing this virtual disk are hidden from VDS.
    // So, Below two fields are used to track the physical and virtual disk ids
    //

    in.hdr.rptag = WIM_IO_REPARSE_TAG_WOF;
    in.hdr.rpdatalen = sizeof(in) - sizeof(in.hdr);
    in.hdr.rpreserved = 0;

