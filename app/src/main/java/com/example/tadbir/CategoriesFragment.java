package com.example.tadbir;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

public class CategoriesFragment extends Fragment {

    Button btnDafn;
    Button btnRestaurant;

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View root = inflater.inflate(R.layout.fragment_categories, container, false);
        btnDafn = root.findViewById(R.id.dafnBtn);
        btnRestaurant = root.findViewById(R.id.restaurantBtn);
        btnRestaurant.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                getFragmentManager().beginTransaction().replace(R.id.fragment_container,
                        new ToyFragment()).commit();
            }
        });

        btnDafn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                getFragmentManager().beginTransaction().replace(R.id.fragment_container,
                        new DafnFragment()).commit();
            }
        });

        return root;
    }
}
