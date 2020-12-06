package com.example.tadbir;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class Toy {
    @SerializedName("CompanyId")
    @Expose
    public Long companyId;
    @SerializedName("CompanyName")
    @Expose
    public String companyName;
    @SerializedName("CompanyInn")
    @Expose
    public String companyInn;
    @SerializedName("CompanyPhone")
    @Expose
    public String companyPhone;
    @SerializedName("CompanyEmail")
    @Expose
    public String companyEmail;
    @SerializedName("CompanyWebsite")
    @Expose
    public String companyWebsite;
}
