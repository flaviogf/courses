package br.com.flaviogf.technews.adapters;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;

import br.com.flaviogf.technews.R;
import br.com.flaviogf.technews.models.News;

public class NewsListAdapter extends BaseAdapter {
    private final Context context;
    private final List<News> news = new ArrayList<>();

    public NewsListAdapter(Context context) {
        this.context = context;
    }

    @Override
    public int getCount() {
        return news.size();
    }

    @Override
    public News getItem(int position) {
        return news.get(position);
    }

    @Override
    public long getItemId(int position) {
        return 0;
    }

    @Override
    public View getView(int position, View view, ViewGroup viewGroup) {
        View layout = LayoutInflater.from(context).inflate(R.layout.item_news, viewGroup, false);

        TextView titleTextView = layout.findViewById(R.id.item_news_title);
        TextView contentTextView = layout.findViewById(R.id.item_news_content);

        News news = this.news.get(position);

        titleTextView.setText(news.getTitle());
        contentTextView.setText(news.getContent());

        return layout;
    }

    public void update(List<News> news) {
        this.news.clear();
        this.news.addAll(news);
        notifyDataSetChanged();
    }

    public void remove(News news) {
        this.news.remove(news);
        notifyDataSetChanged();
    }
}
