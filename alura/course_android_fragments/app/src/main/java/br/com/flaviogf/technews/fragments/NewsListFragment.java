package br.com.flaviogf.technews.fragments;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProvider;
import androidx.recyclerview.widget.RecyclerView;

import com.google.android.material.floatingactionbutton.FloatingActionButton;

import java.util.List;

import br.com.flaviogf.technews.R;
import br.com.flaviogf.technews.adapters.NewsListAdapter;
import br.com.flaviogf.technews.models.News;
import br.com.flaviogf.technews.repositories.MemoryNewsRepository;
import br.com.flaviogf.technews.repositories.NewsRepository;
import br.com.flaviogf.technews.viewmodels.NewsListViewModel;
import br.com.flaviogf.technews.viewmodels.NewsListViewModelFactory;

public class NewsListFragment extends Fragment {
    private NewsListViewModel viewModel;
    private NewsListAdapter newsListAdapter;
    private RecyclerView newsListRecyclerView;
    private FloatingActionButton floatingActionButton;
    private OnClickNewsListener onClickNewsListener;
    private OnFloatingActionButtonClickListener onFloatingActionButtonClickListener;

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        NewsRepository newsRepository = new MemoryNewsRepository();

        NewsListViewModelFactory factory = new NewsListViewModelFactory(newsRepository);

        viewModel = new ViewModelProvider(this, factory).get(NewsListViewModel.class);

        newsListAdapter = new NewsListAdapter(getContext());

        newsListAdapter.setOnClickNewsListener(onClickNewsListener::onClick);
    }

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_news_list, container, false);

        newsListRecyclerView = view.findViewById(R.id.fragment_news_list_recycler_view);
        newsListRecyclerView.setHasFixedSize(true);
        newsListRecyclerView.setAdapter(newsListAdapter);

        floatingActionButton = view.findViewById(R.id.fragment_news_list_floating_action_button);

        floatingActionButton.setOnClickListener((it) -> onFloatingActionButtonClickListener.onClick());

        return view;
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        viewModel.fetch().observe(this, (result) -> {
            if (result.isFailure()) {
                Toast.makeText(getContext(), result.getMessage(), Toast.LENGTH_SHORT).show();
                return;
            }

            List<News> news = result.getValue();

            newsListAdapter.update(news);
        });
    }

    public void setOnClickNewsListener(OnClickNewsListener onClickNewsListener) {
        this.onClickNewsListener = onClickNewsListener;
    }

    public void setOnFloatingActionButtonClickListener(OnFloatingActionButtonClickListener onFloatingActionButtonClickListener) {
        this.onFloatingActionButtonClickListener = onFloatingActionButtonClickListener;
    }

    public interface OnClickNewsListener {
        void onClick(News news);
    }

    public interface OnFloatingActionButtonClickListener {
        void onClick();
    }
}
