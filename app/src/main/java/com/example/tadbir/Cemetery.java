package com.example.tadbir;

import com.google.gson.annotations.SerializedName;

public class Cemetery {
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
    @SerializedName("Email")
    public String email;
    @SerializedName("Website")
    public String website;
}
