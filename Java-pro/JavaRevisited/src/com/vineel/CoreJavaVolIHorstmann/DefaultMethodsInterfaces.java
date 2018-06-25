package com.vineel.CoreJavaVolIHorstmann;

/**
 * Created by Vineel on 2/26/2016.
 */

interface IBankAccount{
    default int getMinBalance(){
        return 1000;
    }
}

class VineelAccount implements IBankAccount {
    public void printMinBalance(){
        System.out.println(getMinBalance());
    }
}

public class DefaultMethodsInterfaces {
    public static void main(String[] args) {
        VineelAccount va = new VineelAccount();
        va.printMinBalance();
    }
}
