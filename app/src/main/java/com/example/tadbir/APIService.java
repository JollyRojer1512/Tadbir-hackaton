package com.example.tadbir;

import retrofit2.Call;
import retrofit2.http.GET;

public interface APIService {
    @GET("company/{id}")
    Call<Toy> getCompany(int id);
}
