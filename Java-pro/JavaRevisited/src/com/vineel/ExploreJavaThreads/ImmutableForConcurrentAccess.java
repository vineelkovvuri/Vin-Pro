package com.vineel.ExploreJavaThreads;

import java.util.Arrays;

/**
 * Created by vineelkumarr on 17/12/2014.
 * This program demonstrates the use of immutable class to help provide concurrent access to
 * method findFactors()
 */

/**
 *  This class is not properly synchronized.
 */
class BigIntegerFactor {
    public Integer lastNumber = 0;
    public Integer[] lastNumberFactors = {0};

    public Integer[] findFactors(Integer i) {
        if (!i.equals(lastNumber)) {
            /* the below two stmts could cause corruption in the global state */
            lastNumberFactors = doFactors(i);
            lastNumber = i;
        }
        return lastNumberFactors;
    }

    private Integer[] doFactors(Integer i) {
        /* code to find the factors of a given number */
        return null;
    }
}

/**
 *  This class provides concurrent execution of findFactors method with the use of
 *  immutable FactorCache class
 */
class BigIntegerFactorCached {
    // collectively we will assign an immutable FactorCache object every time a new factor has to be found
    public FactorCache cache = new FactorCache(null, null);

    public Integer[] findFactors(Integer i) {
        Integer factors[] = cache.getFactors(i);
        if (factors == null) {
            factors = doFactors(i);
            /* since new FactorCache(i, factors) is an immutable class
                Because it is immutable we can care freely use the newly constructed object
                since it does not have any connection with the simultaneous executing threads data.
                Also, The assignment make the state of global variable atomic
             */
            cache = new FactorCache(i, factors);
        }
        return factors;
    }

    private Integer[] doFactors(Integer i) {
        /* code to find the factors of a given number */
        return null;
    }
    /* Immutable class to hold the factors of the last number.
    *  To make a class immutable we need to following below principles
    *  - All fields should be final
    *  - Its state cannot be modified once constructed
    *     - This means we should not hold on to outside objects
    *     - This means we should not
    *  */
    private class FactorCache {
        private final Integer lastNumber; /* marking final makes the lastNumber fixed */
        private final Integer lastNumberFactors[];

        public FactorCache(Integer lastNumber, Integer lastNumberFactors[]) {
            this.lastNumber = lastNumber;
            /* do not hold on to outside object - because modifying them from outside can change the state of
               this object
             */
            this.lastNumberFactors = Arrays.copyOf(lastNumberFactors, lastNumberFactors.length);
        }

        public Integer[] getFactors(Integer i) {
            if (lastNumber == null || !lastNumber.equals(i))
                return null;
            else/* no outsider should be able to modify the state of this object by changing lastNumberFactors */
                return Arrays.copyOf(lastNumberFactors, lastNumberFactors.length);
        }
    }
}

public class ImmutableForConcurrentAccess {
}
