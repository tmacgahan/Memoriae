using System;

public class Errors {
    public static void HaltAndCatchFire( string withMsg ) {
        throw new System.Exception( withMsg );
    }
}