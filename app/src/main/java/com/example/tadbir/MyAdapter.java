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

public class MyAdapter extends RecyclerView.Adapter<MyAdapter.ViewHolder> {
    private Context context;
    private List<ListData> listData;
    private ItemClickListener itemClickListener;

    public MyAdapter(Context context, List<ListData> listData, ItemClickListener itemClickListener) {
        this.context = context;
        this.listData = listData;
        this.itemClickListener = itemClickListener;
    }

    @NonNull
    @Override
    public MyAdapter.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.data_list, parent, false);
        return new ViewHolder(view, itemClickListener);
    }

    @Override
    public void onBindViewHolder(@NonNull MyAdapter.ViewHolder holder, int position) {
        ListData item = listData.get(position);
        holder.item_name.setText(item.getName());
        holder.desc.setText(item.getDescription());
    }

    @Override
    public int getItemCount() {
        return listData.size();
    }

    public static class ViewHolder extends RecyclerView.ViewHolder implements View.OnClickListener {
        public TextView item_name;
        public TextView desc;
        public RelativeLayout relativeLayout;
        public ItemClickListener itemClickListener;
        
        public ViewHolder(@NonNull View itemView, ItemClickListener itemClickListener) {
            super(itemView);
            item_name = itemView.findViewById(R.id.name);
            desc = itemView.findViewById(R.id.description);
            relativeLayout = itemView.findViewById(R.id.main1);
            relativeLayout.setOnClickListener(this);
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
