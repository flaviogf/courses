package br.com.flaviogf.technews.adapters;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.util.ArrayList;
import java.util.List;

import br.com.flaviogf.technews.R;
import br.com.flaviogf.technews.models.News;

public class NewsListAdapter extends RecyclerView.Adapter<NewsListAdapter.NewsViewHolder> {
    private final Context context;
    private final List<News> news = new ArrayList<>();
    private OnClickNewsListener onClickNewsListener;

    public NewsListAdapter(Context context) {
        this.context = context;
    }

    @NonNull
    @Override
    public NewsViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(context).inflate(R.layout.item_news, parent, false);
        return new NewsViewHolder(view, onClickNewsListener);
    }

    @Override
    public void onBindViewHolder(@NonNull NewsViewHolder holder, int position) {
        News news = this.news.get(position);
        holder.bind(news);
    }

    @Override
    public int getItemCount() {
        return news.size();
    }

    public void setOnClickNewsListener(OnClickNewsListener onClickNewsListener) {
        this.onClickNewsListener = onClickNewsListener;
    }

    public void update(List<News> news) {
        this.news.clear();
        this.news.addAll(news);
        notifyDataSetChanged();
    }

    public static class NewsViewHolder extends RecyclerView.ViewHolder {
        private final TextView titleTextView;
        private final TextView contentTextView;
        private final OnClickNewsListener onClickNewsListener;

        public NewsViewHolder(@NonNull View itemView, OnClickNewsListener onClickNewsListener) {
            super(itemView);

            this.onClickNewsListener = onClickNewsListener;

            titleTextView = itemView.findViewById(R.id.item_news_title);
            contentTextView = itemView.findViewById(R.id.item_news_content);
        }

        public void bind(News news) {
            itemView.setOnClickListener((it) -> onClickNewsListener.onClick(news));

            titleTextView.setText(news.getTitle());
            contentTextView.setText(news.getContent());
        }
    }

    public interface OnClickNewsListener {
        void onClick(News news);
    }
}
