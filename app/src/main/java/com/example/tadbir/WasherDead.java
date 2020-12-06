package com.example.tadbir;

import com.google.gson.annotations.SerializedName;

public class WasherDead {
    @SerializedName("Id")
    public long id;
    @SerializedName("FirstName")
    public String firstName;
    @SerializedName("LastName")
    public String lastName;
    @SerializedName("RequiredPhoneNumber")
    public String phoneNumber;
    @SerializedName("AdditionalPhoneNumber")
    public String additionalPhoneNumber;
    @SerializedName("City")
    public String city;
    @SerializedName("District")
    public String district;
}
