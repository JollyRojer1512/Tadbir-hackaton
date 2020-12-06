package com.example.tadbir;

import android.content.Intent;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import java.util.List;
import java.util.ArrayList;


public class ToyFragment extends Fragment implements MyAdapter.ItemClickListener {
    private RecyclerView recyclerView;
    private RecyclerView.Adapter adapter;
    private List<ListData> listData;

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View root = inflater.inflate(R.layout.fragment_restaurants, container, false);

        recyclerView = root.findViewById(R.id.recycler_view);
        recyclerView.setHasFixedSize(true);
        recyclerView.setLayoutManager(new LinearLayoutManager(getContext()));

        listData = new ArrayList<>();

        for (int i = 0; i <= 10; i++){
            ListData item = new ListData(
                    "To'y " + (i+1),
                    "Narxi " + (100+i)
            );
            listData.add(item);
        }

        adapter = new MyAdapter(getContext(), listData, this);
        recyclerView.setAdapter(adapter);

        return root;
    }

    @Override
    public void onItemClick(View v, int position) {
        //
        ListData temp = listData.get(position);
        Intent i = new Intent();
        Toast.makeText(getContext(), "Hello " + position, Toast.LENGTH_SHORT).show();
    }
}
