package com.vineel.CoreJavaVolIHorstmann;

/**
 * Created by vineel on 3/3/16.
 */

class IPhone<T extends Material>
{
    T material;

    public IPhone(T material) {
        this.material = material;
    }

    public String getDetails() {
        return material.getName();
    }
}

abstract class Material {
    public abstract String getName();
}

class Gold extends Material
{
    @Override
    public String getName() {
        return "Gold iPhone";
    }
}

class Silver extends Material
{
    @Override
    public String getName() {
        return "Silver iPhone";
    }
}

public class Temp {
    public static void main(String[] args) {
        IPhone<Gold> goldIPhone = new IPhone<>(new Gold());
        IPhone<Silver> silverIPhone = new IPhone<>(new Silver());

        getDetails(goldIPhone);
        getDetails(silverIPhone);

    }

    public static void getDetails(IPhone<? extends Material> iphone){
        System.out.println(iphone.getDetails());
    }
}
