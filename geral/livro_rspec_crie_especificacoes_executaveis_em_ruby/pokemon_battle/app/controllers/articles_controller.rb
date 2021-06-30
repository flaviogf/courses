# frozen_string_literal: true

class ArticlesController < ApplicationController
  def create
    @article = Article.new(article_params)

    @article.save
  end

  def show
    @article = Article.find(params['id'])
  end

  private

  def article_params
    params.require(:article).permit(:title, :user_id)
  end
end
