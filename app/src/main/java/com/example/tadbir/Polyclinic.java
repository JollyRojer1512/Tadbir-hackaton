package com.example.tadbir;

import com.google.gson.annotations.SerializedName;

public class Polyclinic {
    @SerializedName("Id")
    public long id;
    @SerializedName("Name")
    public String firstName;
    @SerializedName("RequiredPhoneNumber")
    public String phoneNumber;
    @SerializedName("AdditionalPhoneNumber")
    public String additionalPhoneNumber;
    @SerializedName("City")
    public String city;
    @SerializedName("District")
    public String district;
}
