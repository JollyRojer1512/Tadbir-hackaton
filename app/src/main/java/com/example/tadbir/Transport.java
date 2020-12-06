package com.example.tadbir;

import com.google.gson.annotations.SerializedName;

public class Transport {
    @SerializedName("Id")
    public long id;
    @SerializedName("StateNumber")
    public String stateNumber ;
    @SerializedName("DriverFirstName")
    public String driverFirstName ;
    @SerializedName("DriverLastName")
    public String driverLastName ;
    @SerializedName("AdditionalPhoneNumber")
    public String additionalPhoneNumber;
    @SerializedName("DriverRequiredPhoneNumber")
    public String driverRequiredPhoneNumber ;
    @SerializedName("DriverAdditionalPhoneNumber")
    public String driverAdditionalPhoneNumber ;
    @SerializedName("City")
    public String city ;
    @SerializedName("District")
    public String district;
}
