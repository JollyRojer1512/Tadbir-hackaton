package com.example.tadbir;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

public class NewAnnouncementFragment extends Fragment {
    EditText cityName;
    EditText restaurantName;
    EditText districtName;
    EditText addressName;
    EditText tel;

    TextView warningText;

    Button submitBtn;

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View root = inflater.inflate(R.layout.fragment_new_announcement, container, false);
        cityName = root.findViewById(R.id.name_of_city);
        restaurantName = root.findViewById(R.id.name_of_restaurant);
        districtName = root.findViewById(R.id.district);
        addressName = root.findViewById(R.id.address);
        tel = root.findViewById(R.id.phones);

        submitBtn = root.findViewById(R.id.submitBtn);

        warningText = root.findViewById(R.id.warningTxt);

        submitBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String strCityName = cityName.getText().toString();
                String strRestName = restaurantName.getText().toString();
                String strDistrictName = districtName.getText().toString();
                String strAddrName = addressName.getText().toString();
                String strTel = tel.getText().toString();

                if (strCityName.isEmpty() || strRestName.isEmpty() || strDistrictName.isEmpty()
                        || strAddrName.isEmpty() || strTel.isEmpty())
                    warningText.setText("All fields must be filled");
                else warningText.setText("");
            }
        });

        return root;
    }
}
