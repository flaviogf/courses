package br.com.flaviogf.technews.activities;

import android.os.Bundle;

import androidx.annotation.IdRes;
import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;

import br.com.flaviogf.technews.R;
import br.com.flaviogf.technews.fragments.NewsFragment;
import br.com.flaviogf.technews.fragments.NewsListFragment;

public class MainActivity extends AppCompatActivity {
    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        setTitle("Tech News");

        if (savedInstanceState != null) {
            return;
        }

        setFragment(newsListFragment(), R.id.main_activity_news_list_container, "@news-list", false, null);
    }

    @Override
    public void onAttachFragment(@NonNull Fragment fragment) {
        super.onAttachFragment(fragment);

        if (fragment instanceof NewsListFragment) {
            NewsListFragment newsListFragment = (NewsListFragment) fragment;

            newsListFragment.setOnClickNewsListener((it) -> {
                Bundle bundle = new Bundle();
                bundle.putString("@news-id", it.getId());
                setFragment(newsFragment(), R.id.main_activity_news_list_container, "@news", true, bundle);
            });

            newsListFragment.setOnFloatingActionButtonClickListener(() -> {
                setFragment(newsFragment(), R.id.main_activity_news_list_container, "@news", true, null);
            });
        }

        if (fragment instanceof NewsFragment) {
            NewsFragment newsFragment = (NewsFragment) fragment;

            newsFragment.setOnOptionsItemDoneSelectedListener(() -> {
                popFragment();
            });
        }
    }

    private NewsListFragment newsListFragment() {
        return new NewsListFragment();
    }

    private NewsFragment newsFragment() {
        return new NewsFragment();
    }

    private void setFragment(Fragment fragment, @IdRes int containerViewId, String tag, Boolean addToBackStack, Bundle bundle) {
        FragmentManager fragmentManager = getSupportFragmentManager();

        FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();

        fragmentTransaction.replace(containerViewId, fragment, tag);

        if (addToBackStack) {
            fragmentTransaction.addToBackStack(null);
        }

        fragment.setArguments(bundle);

        fragmentTransaction.commit();
    }

    private void popFragment() {
        FragmentManager fragmentManager = getSupportFragmentManager();

        fragmentManager.popBackStack();
    }
}
