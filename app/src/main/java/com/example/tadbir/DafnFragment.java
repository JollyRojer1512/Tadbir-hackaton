package com.example.tadbir;

import android.content.Intent;
import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class DafnFragment extends Fragment implements DafnAdapter.ItemClickListener{

    private RecyclerView recyclerView;
    private RecyclerView.Adapter adapter;
    private List<ListData> listData;


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View root = inflater.inflate(R.layout.fragment_dafn, container, false);

        recyclerView = root.findViewById(R.id.recycler_view_sub_dafn);
        recyclerView.setHasFixedSize(true);
        recyclerView.setLayoutManager(new LinearLayoutManager(getContext()));

        final String BASE_URL = "https://tadbir.uz/api/";
        Retrofit retrofit = new Retrofit.Builder()
                .baseUrl(BASE_URL)
                .addConverterFactory(GsonConverterFactory.create())
                .build();

        APIService apiService = retrofit.create(APIService.class);
        apiService.getCompany(1).enqueue(new Callback<Toy>() {
            @Override
            public void onResponse(Call<Toy> call, Response<Toy> response) {
                if (response.isSuccessful()) {
                    Log.d("mTag", "Result: " + response.body().companyName);
                } else {
                    Log.d("mTag", "Xatolik yuz berdi: " + response.errorBody());
                }
            }

            @Override
            public void onFailure(Call<Toy> call, Throwable t) {

            }
        });

        listData = new ArrayList<>();

        for (int i = 0; i <= 10; i++){
            ListData item = new ListData(
                    "Sub-Dafn " + (i+1),
                    "tel " + (100+i)
            );
            listData.add(item);
        }

        adapter = new DafnAdapter(getContext(), listData, this);
        recyclerView.setAdapter(adapter);

        return root;
    }

    @Override
    public void onItemClick(View v, int position) {
        //
        ListData temp = listData.get(position);
        Intent i = new Intent();
        Toast.makeText(getContext(), "in dafn " + position, Toast.LENGTH_SHORT).show();
    }
}