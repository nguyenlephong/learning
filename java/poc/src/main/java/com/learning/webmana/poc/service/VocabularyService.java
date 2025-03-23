package com.learning.webmana.poc.service;
import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.learning.webmana.poc.model.Vocabulary;

import jakarta.annotation.PostConstruct;

import org.springframework.stereotype.Service;
import org.springframework.beans.factory.annotation.Value;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

@Service
public class VocabularyService {
    private final ObjectMapper objectMapper = new ObjectMapper();
    private List<Vocabulary> vocabularyList = new ArrayList<>();

    @Value("${miniapp.vocabulary.file-path}")
    private String filePath;

    // ✅ Remove constructor and use @PostConstruct instead
    @PostConstruct
    public void init() {
        System.out.println("📂 Vocabulary file path: " + filePath);
        loadVocabulary();
    }

    private void loadVocabulary() {
        File file = new File(filePath);
        if (!file.exists()) {
            System.out.println("⚠️ File does not exist. Creating a new one.");
            saveVocabulary(); // Create the file if it doesn't exist
            return;
        }

        try {
            vocabularyList = objectMapper.readValue(file, new TypeReference<List<Vocabulary>>() {});
            System.out.println("✅ Vocabulary loaded: " + vocabularyList.size() + " words");
        } catch (IOException e) {
            System.out.println('❌' + e.getMessage());
            vocabularyList = new ArrayList<>();
        }
    }

    private void saveVocabulary() {
        try {
            objectMapper.writeValue(new File(filePath), vocabularyList);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public List<Vocabulary> getAllWords() {
        return vocabularyList;
    }

    public Vocabulary addWord(Vocabulary vocabulary) {
        vocabularyList.add(vocabulary);
        saveVocabulary();
        return vocabulary;
    }

    public Vocabulary updateWord(String word, Vocabulary updatedVocabulary) {
        for (Vocabulary v : vocabularyList) {
            if (v.getWord().equalsIgnoreCase(word)) {
                v.setMeaning(updatedVocabulary.getMeaning());
                saveVocabulary();
                return v;
            }
        }
        return null;
    }

    public boolean deleteWord(String word) {
        boolean removed = vocabularyList.removeIf(v -> v.getWord().equalsIgnoreCase(word));
        if (removed) saveVocabulary();
        return removed;
    }
}