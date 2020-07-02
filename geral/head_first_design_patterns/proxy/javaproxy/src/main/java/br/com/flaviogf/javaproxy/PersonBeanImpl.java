package br.com.flaviogf.javaproxy;

public class PersonBeanImpl implements PersonBean {
    private String name;
    private String gender;
    private String interest;
    private Integer rating = 0;
    private Integer count = 0;

    @Override
    public String getName() {
        return name;
    }

    @Override
    public String getGender() {
        return gender;
    }

    @Override
    public String getInterest() {
        return interest;
    }

    @Override
    public Integer getHotOrNotRating() {
        if (count <= 0) return 0;

        return rating / count;
    }

    @Override
    public void setName(String name) {
        this.name = name;
    }

    @Override
    public void setGender(String gender) {
        this.gender = gender;
    }

    @Override
    public void setInterest(String interest) {
        this.interest = interest;
    }

    @Override
    public void setHorOrNotRating(Integer rating) {
        this.rating += rating;

        count++;
    }
}
