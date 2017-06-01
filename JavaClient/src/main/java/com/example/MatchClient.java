package com.example;

import com.example.domain.Match;
import org.hibernate.service.spi.ServiceException;
import org.springframework.web.client.HttpClientErrorException;
import org.springframework.web.client.ResourceAccessException;
import org.springframework.web.client.RestTemplate;

import java.util.concurrent.Callable;

/**
 * Created by Sergiu on 5/22/2017.
 */
public class MatchClient {
    public static final String URL = "http://localhost:8080/matches";

    private RestTemplate restTemplate = new RestTemplate();

    private <T> T execute(Callable<T> callable) {
        try {
            return callable.call();
        } catch (Exception e) {
            throw new ServiceException(e.getMessage());
        }
    }

    public Match[] getAll() {
        return execute(() -> restTemplate.getForObject(URL, Match[].class));
    }

    public Match getById(String id) {
        return execute(() -> restTemplate.getForObject(String.format("%s/%s", URL, id), Match.class));
    }

    public void create(Match match) {

        try {
            restTemplate.postForObject(URL, match, Match.class);
        }catch (Exception e)
        {
            //ignored
        }
    }

    public void update(Match user) {
            execute(() -> {
                try{
                    restTemplate.put(String.format("%s/%s", URL, user.getId()), user);
                }catch (Exception e)
                {
                    e.printStackTrace();
                }
                return true;
            });
    }

    public String delete(String id) {
        return execute(() -> {
            restTemplate.delete(String.format("%s/%s", URL, id));
            return restTemplate.getMessageConverters().toString();
        });
    }
}
