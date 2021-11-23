module Counter
  def increment
    session[:counter] ||= 0
    session[:counter] += 1
    logger.info "The current user entered #{session[:counter]} at the store page"
  end

  def reset
    session[:counter] = nil
  end
end
