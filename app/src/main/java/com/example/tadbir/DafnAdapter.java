package com.example.tadbir;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.RelativeLayout;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.util.List;

public class DafnAdapter extends RecyclerView.Adapter<DafnAdapter.ViewHolder> {
    private Context context;
    private List<ListData> listData;
    private ItemClickListener itemClickListener;

    public DafnAdapter(Context context, List<ListData> listData, ItemClickListener itemClickListener) {
        this.context = context;
        this.listData = listData;
        this.itemClickListener = itemClickListener;
    }

    @NonNull
    @Override
    public DafnAdapter.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.data_list_dafn, parent, false);
        return new ViewHolder(view, itemClickListener);
    }

    @Override
    public void onBindViewHolder(@NonNull DafnAdapter.ViewHolder holder, int position) {
        ListData item = listData.get(position);
        holder.subCategoryDafnTxt.setText(item.getName());
    }

    @Override
    public int getItemCount() {
        return listData.size();
    }

    public static class ViewHolder extends RecyclerView.ViewHolder implements View.OnClickListener {
        public TextView subCategoryDafnTxt;
        public TextView subCategoryDafnBtn;

        public ItemClickListener itemClickListener;
        
        public ViewHolder(@NonNull View itemView, ItemClickListener itemClickListener) {
            super(itemView);
            subCategoryDafnTxt = itemView.findViewById(R.id.subCategoryDafnTxt);
            subCategoryDafnBtn = itemView.findViewById(R.id.subCategoryDafnBtn);
            subCategoryDafnBtn.setOnClickListener(this);
            this.itemClickListener = itemClickListener;
        }

        @Override
        public void onClick(View v) {
            itemClickListener.onItemClick(v, getAdapterPosition());
        }
    }

    public interface ItemClickListener{
        public void onItemClick(View v, int position);
    }

}
